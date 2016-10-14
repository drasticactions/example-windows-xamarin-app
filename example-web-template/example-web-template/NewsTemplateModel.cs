using System;
using windows_central_client.Models.News;

namespace example_web_template
{
	public class NewsTemplateModel
	{
		public Article Article { get; set; }

        public AppPlatform Platform { get; set; }

		public Theme Theme { get; set; }
	}

    public enum AppPlatform
    {
        iOS,
        Android,
        Windows
    }

	public enum Theme
	{
		Light,
		Dark
	}
}
