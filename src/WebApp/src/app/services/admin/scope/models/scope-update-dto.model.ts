import { AdditionProperty } from '../../models/addition-property.model';
/**
 * Scope更新时请求结构
 */
export interface ScopeUpdateDto {
  description?: string | null;
  displayName?: string | null;
  name?: string | null;
  properties?: AdditionProperty[] | null;

}
