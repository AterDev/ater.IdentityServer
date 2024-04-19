import { ApplicationType } from '../enum/application-type.model';
import { ClientType } from '../enum/client-type.model';
import { ConsentType } from '../enum/consent-type.model';
/**
 * Application查询筛选
 */
export interface ApplicationFilterDto {
  pageIndex: number;
  pageSize: number;
  orderBy?: any | null;
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

}
