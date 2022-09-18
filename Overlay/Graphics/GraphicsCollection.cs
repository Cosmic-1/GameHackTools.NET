using System.Linq.Expressions;

namespace Overlay.Graphics
{
    public class GraphicsCollection
    {
        private readonly List<IGraphics> graphicsList = new ();
        public GraphicsCollection(IGraphics[] graphics)
        {
            this.graphicsList.AddRange(graphics ?? throw new NullReferenceException(nameof(graphics)));
        }

        public IGraphics[] Graphics => graphicsList.ToArray();

        /// <summary>
        /// Render all elements
        /// </summary>
        /// <param name="e">Provides data for a drawing.</param>
        /// <returns>true if all render elements were successful or false if there was an exception</returns>
        public bool RenderAll(PaintEventArgs e)
        {
            try
            {
                for (int i = 0; i < graphicsList.Count; i++)
                    Graphics[i].Render(e);

               return true;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Add graphics to the collection
        /// </summary>
        /// <param name="graphics">The element needs to be added</param>
        /// <exception cref="NullReferenceException">When the element is null</exception>
        public void Add(IGraphics graphics)
        {
            this.graphicsList.Add(graphics ?? throw new NullReferenceException(nameof(graphics)));
        }
        /// <summary>
        /// Remove graphics from collection
        /// </summary>
        /// <param name="graphics">The element needs to be remote</param>
        /// <returns>true if the element was  successfully removed from the collection, or false if it was not removed</returns>
        public bool Remove(IGraphics graphics)
        {
            return this.graphicsList.Remove(graphics);
        }
        /// <summary>
        /// Remove the graphics by id from the collection
        /// </summary>
        /// <param name="graphicsId">The id element needs to be remote</param>
        public void RemoveAt(int graphicsId)
        {
            this.graphicsList.RemoveAt(graphicsId);
        }
    }
}
