import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { Observable } from 'rxjs';
import { RegisterDto } from './models/register-dto.model';
import { SystemUserUpdateDto } from './models/system-user-update-dto.model';
import { LoginDto } from './models/login-dto.model';
import { SystemUser } from './models/system-user.model';
import { LoginResult } from './models/login-result.model';

/**
 * 用户账户
 */
@Injectable({ providedIn: 'root' })
export class SystemUserBaseService extends BaseService {
  /**
   * 用户注册 ✅
   * @param data RegisterDto
   */
  register(data: RegisterDto): Observable<SystemUser> {
    const _url = `/api/admin/SystemUser`;
    return this.request<SystemUser>('post', _url, data);
  }

  /**
   * 更新信息：头像 ✅
   * @param data SystemUserUpdateDto
   */
  update(data: SystemUserUpdateDto): Observable<boolean> {
    const _url = `/api/admin/SystemUser`;
    return this.request<boolean>('put', _url, data);
  }

  /**
   * 详情 ✅
   */
  getDetail(): Observable<SystemUser> {
    const _url = `/api/admin/SystemUser`;
    return this.request<SystemUser>('get', _url);
  }

  /**
   * 登录获取Token ✅
   * @param data LoginDto
   */
  login(data: LoginDto): Observable<LoginResult> {
    const _url = `/api/admin/SystemUser/login`;
    return this.request<LoginResult>('put', _url, data);
  }

  /**
   * 退出 ✅
   * @param id string
   */
  logout(id: string): Observable<boolean> {
    const _url = `/api/admin/SystemUser/logout/${id}`;
    return this.request<boolean>('put', _url);
  }

  /**
   * 修改密码 ✅
   * @param password string
   * @param newPassword string
   */
  changePassword(password: string | null, newPassword: string | null): Observable<boolean> {
    const _url = `/api/admin/SystemUser/changePassword?password=${password ?? ''}&newPassword=${newPassword ?? ''}`;
    return this.request<boolean>('put', _url);
  }

}
