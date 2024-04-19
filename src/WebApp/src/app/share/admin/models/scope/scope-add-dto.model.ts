import { AdditionProperty } from '../addition-property.model';
/**
 * Scope添加时请求结构
 */
export interface ScopeAddDto {
  description?: string | null;
  displayName?: string | null;
  name?: string | null;
  properties?: AdditionProperty[];

}
