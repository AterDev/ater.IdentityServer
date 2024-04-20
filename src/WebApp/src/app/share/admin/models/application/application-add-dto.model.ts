import { ApplicationType } from '../enum/application-type.model';
import { ClientType } from '../enum/client-type.model';
import { ConsentType } from '../enum/consent-type.model';
/**
 * Application添加时请求结构
 */
export interface ApplicationAddDto {
  applicationType?: ApplicationType | null;
  /**
   * ClientId
   */
  clientId: string;
  /**
   * Secret
   */
  clientSecret?: string | null;
  clientType?: ClientType | null;
  /**
   * 知情同意
   */
  consentType?: ConsentType | null;
  /**
   * 名称
   */
  displayName: string;
  /**
   * The permissions of application.
   */
  permissions: string[];
  /**
   * The post-logout redirect URIs of  application.
   */
  postLogoutRedirectUris: string[];
  /**
   * Gets the redirect URIs associated with the application.
   */
  redirectUris: string[];

}
