using FastWiki.ApiGateway.caller.Service;
using FastWiki.Service.Contracts.ChatApplication;
using FastWiki.Service.Contracts.ChatApplication.Dto;
using Masa.Utils.Models;

namespace FastWiki.ApiGateway.Caller.Service;

public class ChatApplicationService(ICaller caller) : ServiceBase(caller), IChatApplicationService
{
    protected override string BaseUrl { get; set; } = "ChatApplications";

    public async Task CreateAsync(CreateChatApplicationInput input)
    {
        await PostAsync(nameof(CreateAsync), input);
    }

    public async Task RemoveAsync(string id)
    {
        await DeleteAsync(nameof(RemoveAsync) + "/" + id);
    }

    public async Task UpdateAsync(UpdateChatApplicationInput input)
    {
        await PutAsync(nameof(UpdateAsync), input);
    }

    public async Task<PaginatedListBase<ChatApplicationDto>> GetListAsync(int page, int pageSize)
    {
        return await GetAsync<PaginatedListBase<ChatApplicationDto>>(nameof(GetListAsync), new Dictionary<string, string>()
        {
            { "page", page.ToString() },
            { "pageSize", pageSize.ToString() }
        });
    }

    public Task<ChatApplicationDto> GetAsync(string id)
    {
        return GetAsync<ChatApplicationDto>(nameof(GetAsync) + "/" + id);
    }

    public async Task CreateChatDialogAsync(CreateChatDialogInput input)
    {
        await PostAsync(nameof(CreateChatDialogAsync), input);
    }

    public async Task<List<ChatDialogDto>> GetChatDialogAsync()
    {
        return await GetAsync<List<ChatDialogDto>>(nameof(GetChatDialogAsync));
    }

    public IAsyncEnumerable<CompletionsDto> CompletionsAsync(CompletionsInput input)
    {
        throw new NotImplementedException();
    }
}