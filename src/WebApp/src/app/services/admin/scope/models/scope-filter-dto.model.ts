/**
 * Scope查询筛选
 */
export interface ScopeFilterDto {
  pageIndex: number;
  pageSize: number;
  orderBy?: any | null;
  description?: string | null;
  displayName?: string | null;
  name?: string | null;

}
