import { AdditionProperty } from '../addition-property.model';
/**
 * Scope
 */
export interface Scope {
  description?: string | null;
  displayName?: string | null;
  name?: string | null;
  properties?: AdditionProperty[];
  resources: string[];
  id: string;
  createdTime: Date;
  updatedTime: Date;
  isDeleted: boolean;

}
