namespace Watermelon.Common
{
    using Discord;

    /// <summary>
    /// A custom embed builder with a theme.
    /// </summary>
    internal class WatermelonEmbedBuilder : EmbedBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WatermelonEmbedBuilder"/> class.
        /// </summary>
        public WatermelonEmbedBuilder()
        {
            WithColor(new Color(238, 62, 75));
        }
    }
}
