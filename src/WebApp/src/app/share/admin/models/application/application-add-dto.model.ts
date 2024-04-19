import { ApplicationType } from '../enum/application-type.model';
import { ClientType } from '../enum/client-type.model';
import { ConsentType } from '../enum/consent-type.model';
import { AdditionProperty } from '../addition-property.model';
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
   * The properties of application.
   */
  properties?: AdditionProperty[];
  /**
   * Gets the redirect URIs associated with the application.
   */
  redirectUris: string[];
  /**
   * The requirements of application.
   */
  requirements: string[];
  /**
   * The settings of  application.
   */
  settings?: any | null;

}
