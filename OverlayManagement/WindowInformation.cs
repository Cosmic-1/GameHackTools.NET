namespace OverlayManagement
{
    public class WindowInformation
    {
        /// <summary>
        /// Game window name.
        /// </summary>
        private readonly string NAME_GAME_WINDOW;

        private readonly int HEIGHT_TOP_PANEL;
        /// <summary>
        /// Game window handle.
        /// </summary>
        private nint handleWindowGame;
        /// <summary>
        /// Game window client rectangle.
        /// </summary>
        public Rectangle WindowRectangleClient { get; private set; }

        /// <summary>
        /// Checking the window game by name.
        /// </summary>
        /// <returns>true if ptr and the current foreground Window is found, or false if not.</returns>
        public bool IsValid { get; private set; }

        public bool IsWindowHasTopPanel { get; set; } = true;

        public WindowInformation(string nameWindow, int heigthTopPanelWindow = 25)
        {
            HEIGHT_TOP_PANEL = heigthTopPanelWindow;
            NAME_GAME_WINDOW = nameWindow ?? throw new NullReferenceException(nameWindow);
        }

        /// <summary>
        /// Update the window when the game window has changed size.
        /// </summary>
        public void UpdateWindow()
        {
            handleWindowGame = WindowAPI.FindWindow(NAME_GAME_WINDOW);
            IsValid = handleWindowGame != IntPtr.Zero && WindowAPI.GetForegroundWindowCurrent(handleWindowGame);

            if (IsValid)
            {
                var rect = WindowAPI.GetWindowRectangle(handleWindowGame);

                WindowRectangleClient = IsWindowHasTopPanel
                    ? new Rectangle(rect.X, rect.Y + HEIGHT_TOP_PANEL, rect.Width, rect.Height - HEIGHT_TOP_PANEL)
                    : rect;
            }
            else
            {
                WindowRectangleClient = Rectangle.Empty;
            }
        }
    }
}
