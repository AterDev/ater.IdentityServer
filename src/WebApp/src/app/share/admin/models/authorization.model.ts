import { Application } from './application/application.model';
import { AdditionProperty } from './addition-property.model';
import { Status } from './enum/status.model';
import { SubjectType } from './enum/subject-type.model';
import { AuthorizationType } from './enum/authorization-type.model';
import { Token } from './token.model';
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
