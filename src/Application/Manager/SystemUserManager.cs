using Definition.Share.Models.SystemUserDtos;

namespace Application.Manager;
/// <summary>
/// 用户账户
/// </summary>
public class SystemUserManager(
    DataAccessContext<SystemUser> dataContext,
    ILogger<SystemUserManager> logger,
    IUserContext userContext) : ManagerBase<SystemUser>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 更新密码
    /// </summary>
    /// <param name="user"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public async Task<bool> ChangePasswordAsync(SystemUser user, string newPassword)
    {
        user.PasswordSalt = HashCrypto.BuildSalt();
        user.PasswordHash = HashCrypto.GeneratePwd(newPassword, user.PasswordSalt);
        Command.Update(user);
        return await SaveChangesAsync() > 0;
    }

    /// <summary>
    /// 用户注册
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SystemUser> RegisterAsync(RegisterDto dto)
    {
        var user = new SystemUser
        {
            UserName = dto.UserName,
            PasswordSalt = HashCrypto.BuildSalt()
        };
        user.PasswordHash = HashCrypto.GeneratePwd(dto.Password, user.PasswordSalt);
        if (dto.Email != null)
        {
            user.Email = dto.Email;
        }
        await AddAsync(user);
        return user;
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SystemUser> AddAsync(SystemUserAddDto dto)
    {
        var user = new SystemUser
        {
            UserName = dto.UserName,
            PasswordSalt = HashCrypto.BuildSalt()
        };
        user.PasswordHash = HashCrypto.GeneratePwd(dto.Password, user.PasswordSalt);
        if (dto.Email != null)
        {
            user.Email = dto.Email;
        }
        await AddAsync(user);
        return user;
    }

    public async Task<bool> UpdateAsync(SystemUser entity, SystemUserUpdateDto dto)
    {
        if (dto.Password != null && _userContext != null && _userContext.IsAdmin)
        {
            entity.PasswordSalt = HashCrypto.BuildSalt();
            entity.PasswordHash = HashCrypto.GeneratePwd(dto.Password, entity.PasswordSalt);
        }
        return await base.UpdateAsync(entity);
    }

    public async Task<PageList<SystemUserItemDto>> ToPageAsync(SystemUserFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.UserName, q => q.UserName == filter.UserName)
            .WhereNotNull(filter.Email, q => q.Email == filter.Email)
            .WhereNotNull(filter.PhoneNumber, q => q.PhoneNumber == filter.PhoneNumber)
            .WhereNotNull(filter.EmailConfirmed, q => q.EmailConfirmed == filter.EmailConfirmed)
            .WhereNotNull(filter.PhoneNumberConfirmed, q => q.PhoneNumberConfirmed == filter.PhoneNumberConfirmed);

        return await ToPageAsync<SystemUserFilterDto, SystemUserItemDto>(filter);
    }

    /// <summary>
    /// 是否存在
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public async Task<bool> IsExistAsync(string userName)
    {
        return await Query.AnyAsync(q => q.UserName == userName);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SystemUser?> GetOwnedAsync(Guid id)
    {
        IQueryable<SystemUser> query = Command.Where(q => q.Id == id);
        // 获取用户所属的对象
        return await query.FirstOrDefaultAsync();
    }
}
