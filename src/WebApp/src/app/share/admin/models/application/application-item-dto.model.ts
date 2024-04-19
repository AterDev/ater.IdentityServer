import { ApplicationType } from '../enum/application-type.model';
import { ClientType } from '../enum/client-type.model';
import { ConsentType } from '../enum/consent-type.model';
/**
 * Application列表元素
 */
export interface ApplicationItemDto {
  applicationType?: ApplicationType | null;
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
   * The settings of  application.
   */
  settings?: any | null;
  id: string;
  createdTime: Date;

}
