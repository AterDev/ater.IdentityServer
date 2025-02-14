import { ApplicationType } from '../../enum/models/application-type.model';
import { ClientType } from '../../enum/models/client-type.model';
import { ConsentType } from '../../enum/models/consent-type.model';
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
