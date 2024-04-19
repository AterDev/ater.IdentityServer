import { ApplicationType } from '../enum/application-type.model';
import { ClientType } from '../enum/client-type.model';
import { ConsentType } from '../enum/consent-type.model';
import { AdditionProperty } from '../addition-property.model';
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
   * The properties of application.
   */
  properties?: AdditionProperty[] | null;
  /**
   * Gets the redirect URIs associated with the application.
   */
  redirectUris?: string[] | null;
  /**
   * The requirements of application.
   */
  requirements?: string[] | null;
  /**
   * The settings of  application.
   */
  settings?: any | null;
  authorizationIds?: string[] | null;
  tokenIds?: string[] | null;

}
