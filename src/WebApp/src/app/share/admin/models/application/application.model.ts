import { ApplicationType } from '../enum/application-type.model';
import { ClientType } from '../enum/client-type.model';
import { ConsentType } from '../enum/consent-type.model';
import { AdditionProperty } from '../addition-property.model';
import { Authorization } from '../authorization.model';
import { Token } from '../token.model';
/**
 * Application
 */
export interface Application {
  applicationType?: ApplicationType | null;
  /**
   * ClientId
   */
  clientId: string;
  /**
   * ClientSecret
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
   * 权限
   */
  permissions: string[];
  /**
   * 回调地址
   */
  postLogoutRedirectUris: string[];
  /**
   * 额外属性
   */
  properties?: AdditionProperty[];
  /**
   * 回调地址
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
  authorizations?: Authorization[];
  tokens?: Token[];
  id: string;
  createdTime: Date;
  updatedTime: Date;
  isDeleted: boolean;

}
