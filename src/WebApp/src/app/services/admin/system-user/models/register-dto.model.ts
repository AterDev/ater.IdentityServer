/**
 * 用户注册
 */
export interface RegisterDto {
  /**
   * 用户名
   */
  userName: string;
  /**
   * 邮箱
   */
  email?: string | null;
  /**
   * 验证码
   */
  verifyCode?: string | null;
  /**
   * 密码
   */
  password: string;

}
