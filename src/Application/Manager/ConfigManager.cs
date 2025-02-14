using System.Text.Json;

using Definition.Share.Models.ConfigDtos;

namespace Application.Manager;
/// <summary>
/// 配置
/// </summary>
public class ConfigManager(
    DataAccessContext<Config> dataContext,
    ILogger<ConfigManager> logger,
    IUserContext userContext) : ManagerBase<Config>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<Guid?> AddAsync(ConfigAddDto dto)
    {
        var entity = dto.MapTo<ConfigAddDto, Config>();
        entity.Value = JsonDocument.Parse(dto.Value);
        return await AddAsync(entity) ? entity.Id : null;
    }

    public async Task<bool> UpdateAsync(Config entity, ConfigUpdateDto dto)
    {
        if (dto.Value != null)
        {
            entity.Value = JsonDocument.Parse(dto.Value);
        }

        return await UpdateAsync(entity);
    }

    public async Task<PageList<ConfigItemDto>> ToPageAsync(ConfigFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Key, q => q.Key == filter.Key)
            .WhereNotNull(filter.Group, q => q.Group == filter.Group);
        return await ToPageAsync<ConfigFilterDto, ConfigItemDto>(filter);
    }

    /// <summary>
    /// 唯一性判断
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsConflictAsync(string group, string key)
    {
        // 自定义唯一性验证参数和逻辑
        return await Command.AnyAsync(q => q.Group == group && q.Key == key);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Config?> GetOwnedAsync(Guid id)
    {
        var query = Command.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    /// 获取所有枚举信息
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, List<EnumDictionary>> GetEnums()
    {
        // TODO:从缓存中获取
        return EnumHelper.GetAllEnumInfo();
    }
}
