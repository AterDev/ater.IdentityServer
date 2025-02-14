import { Application } from '../application/models/application.model';
import { AdditionProperty } from '../models/addition-property.model';
import { Status } from '../enum/models/status.model';
import { SubjectType } from '../enum/models/subject-type.model';
import { AuthorizationType } from '../enum/models/authorization-type.model';
import { Token } from '../models/token.model';
/**
 * Authorizatio
 */
export interface Authorization {
  applicationId: string;
  /**
   * Application
   */
  application?: Application | null;
  /**
   * Gets the additional properties associated with the authorization.
   */
  properties?: AdditionProperty[];
  /**
   * Gets the scopes associated with the authorization.
   */
  scopes: string[];
  status?: Status | null;
  subject?: SubjectType | null;
  type?: AuthorizationType | null;
  tokens?: Token[];
  id: string;
  createdTime: Date;
  updatedTime: Date;
  isDeleted: boolean;

}
