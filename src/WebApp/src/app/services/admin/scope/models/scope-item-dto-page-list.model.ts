import { ScopeItemDto } from '../../scope/models/scope-item-dto.model';
export interface ScopeItemDtoPageList {
  count: number;
  data?: ScopeItemDto[];
  pageIndex: number;

}
