import { ApplicationType } from '../../enum/models/application-type.model';
import { ClientType } from '../../enum/models/client-type.model';
import { ConsentType } from '../../enum/models/consent-type.model';
/**
 * Application更新时请求结构
 */
export interface ApplicationUpdateDto {
  applicationType?: ApplicationType | null;
  /**
   * ClientId
   */
  clientId?: string | null;
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
  displayName?: string | null;
  /**
   * The permissions of application.
   */
  permissions?: string[] | null;
  /**
   * The post-logout redirect URIs of  application.
   */
  postLogoutRedirectUris?: string[] | null;
  /**
   * Gets the redirect URIs associated with the application.
   */
  redirectUris?: string[] | null;

}
