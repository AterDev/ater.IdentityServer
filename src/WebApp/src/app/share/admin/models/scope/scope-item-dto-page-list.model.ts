import { ScopeItemDto } from '../scope/scope-item-dto.model';
export interface ScopeItemDtoPageList {
  count: number;
  data?: ScopeItemDto[];
  pageIndex: number;

}
