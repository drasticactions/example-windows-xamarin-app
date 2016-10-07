using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp;
using windows_central_client.Models;
using windows_central_client.Models.News;
using windows_central_client.Managers;

namespace example_windows_app.Tools.News
{
    public class NewsSource : IIncrementalSource<Article>
    {
        public async Task<IEnumerable<Article>> GetPagedItemsAsync(Int32 pageIndex, Int32 pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await NewsManager.GetNewsResult(pageIndex, pageSize);
            return result.Articles;
        }
    }
}
