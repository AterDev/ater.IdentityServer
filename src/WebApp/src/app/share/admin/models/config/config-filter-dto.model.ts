/**
 * 配置查询筛选
 */
export interface ConfigFilterDto {
  pageIndex: number;
  pageSize: number;
  orderBy?: any | null;
  group?: string | null;
  key?: string | null;

}
