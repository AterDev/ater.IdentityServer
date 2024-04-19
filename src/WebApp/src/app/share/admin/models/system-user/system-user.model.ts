/**
 * SystemUser
 */
export interface SystemUser {
  /**
   * 用户名
   */
  userName: string;
  /**
   * 邮箱
   */
  email?: string | null;
  emailConfirmed: boolean;
  phoneNumber?: string | null;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd?: Date | null;
  lockoutEnabled: boolean;
  accessFailedCount: number;
  /**
   * 最后登录时间
   */
  lastLoginTime?: Date | null;
  /**
   * 密码重试次数
   */
  retryCount: number;
  /**
   * 头像url
   */
  avatar?: string | null;
  id: string;
  createdTime: Date;
  updatedTime: Date;
  isDeleted: boolean;

}
