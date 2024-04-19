/**
 * 用户账户更新时请求结构
 */
export interface SystemUserUpdateDto {
  password?: string | null;
  email?: string | null;
  /**
   * 头像url
   */
  avatar?: string | null;

}
