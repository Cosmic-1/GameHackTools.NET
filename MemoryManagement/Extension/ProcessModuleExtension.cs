namespace MemoryManagement
{
    public class ProcessModuleExtension : IDisposable
    {
        public ProcessModuleExtension(Process process, ProcessModule module)
        {
            Process = process;
            Module = module;
        }

        public Process Process { get; }
        public ProcessModule Module { get; }

        public void Dispose()
        {
            Module?.Dispose();
        }

        public SModel MemoryReadStruct<SModel>(nint baseAddress) where SModel : struct
        {
            return Memory.ReadStruct<SModel>(Process.Handle, Module.BaseAddress + baseAddress);
        }

        public byte[]? MemoryReadBytes(nint baseAddress, int lenght)
        {
            return Memory.ReadBytes(Process.Handle, Module.BaseAddress + baseAddress, lenght);
        }

        public void MemoryWriteStruct<SModel>(nint baseAddress, SModel model) where SModel : struct
        {
            Memory.WriteStruct(Process.Handle, Module.BaseAddress + baseAddress, model);
        }

        public void MemoryWriteBytes(nint baseAddress, byte[] model)
        {
            Memory.WriteBytes(Process.Handle, Module.BaseAddress + baseAddress, model);
        }

        public int FindPattern(byte[] pattern, string mask)
        {
            byte[] moduleBytes = new byte[Module.ModuleMemorySize];

            if (Memory.TryReadBytes(Process.Handle, Module.BaseAddress, ref moduleBytes))
            {
                for (int i = 0; i < moduleBytes.Length; i++)
                {
                    bool found = false;

                    for (int l = 0; l < mask.Length; l++)
                    {
                        found = mask[l] == '?' || moduleBytes[l + i] == pattern[l];

                        if (found)
                            return i;
                    }
                }
            }

            return 0;
        }

        public nint FindPattern(string sig, nint offset, nint extra, bool relative)
        {
            byte[] moduleDump = new byte[Module.ModuleMemorySize];
            nint moduleAddress = Module.BaseAddress;
            nint processAddress = Process.Handle;


            if (Memory.TryReadBytes(processAddress, moduleAddress, ref moduleDump))
            {
                byte[] pattern = SignatureToPattern(sig);
                string mask = GetSignatureMask(sig);
                IntPtr address = IntPtr.Zero;

                for (int i = 0; i < moduleDump.Length; i++)
                {
                    if (address == IntPtr.Zero && pattern.Length + i < moduleDump.Length)
                    {
                        bool isSuccess = true;

                        for (int k = 0; k < pattern.Length; k++)
                        {
                            if (mask[k] == '?')
                                continue;


                            if (pattern[k] != moduleDump[i + k])
                                isSuccess = false;
                        }

                        if (!isSuccess) continue;

                        if (address == IntPtr.Zero)
                        {
                            var a = moduleAddress + i + offset;
                            if (relative)
                            {
                                var b = Memory.ReadStruct<int>(processAddress, a);
                                return b + extra - moduleAddress;
                            }
                            else
                            {
                                var b = Memory.ReadStruct<int>(processAddress, a);
                                return b + extra;
                            }
                        }
                    }
                }
            }

            return -1;
        }

        private byte[] SignatureToPattern(string sig)
        {
            string[] parts = sig.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            byte[] patternArray = new byte[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "?")
                {
                    patternArray[i] = 0;
                    continue;
                }

                if (!byte.TryParse(parts[i], System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.DefaultThreadCurrentCulture, out patternArray[i]))
                {
                    throw new Exception();
                }
            }

            return patternArray;
        }

        private string GetSignatureMask(string sig)
        {
            string[] parts = sig.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string mask = "";

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "?")
                {
                    mask += "?";
                }
                else
                {
                    mask += "x";
                }
            }

            return mask;
        }

    }
}