import { Application } from '../application/models/application.model';
import { Authorization } from '../models/authorization.model';
import { AdditionProperty } from '../models/addition-property.model';
import { Status } from '../enum/models/status.model';
import { SubjectType } from '../enum/models/subject-type.model';
import { TokenType } from '../enum/models/token-type.model';
/**
 * Token
 */
export interface Token {
  applicationId: string;
  /**
   * Application
   */
  application?: Application | null;
  authorizationId: string;
  /**
   * Authorizatio
   */
  authorization?: Authorization | null;
  /**
   * 过期日期
   */
  expirationDate?: Date | null;
  /**
   * payload
   */
  payload?: string | null;
  properties?: AdditionProperty[];
  /**
   * 赎回
   */
  redemptionDate?: Date | null;
  /**
   * Gets or sets the reference identifier associated with the token.
Note: depending on the application manager used when creating it,
this property may be hashed or encrypted for security reasons.
   */
  referenceId?: string | null;
  status?: Status | null;
  subject?: SubjectType | null;
  type?: TokenType | null;
  id: string;
  createdTime: Date;
  updatedTime: Date;
  isDeleted: boolean;

}
