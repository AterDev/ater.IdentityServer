import { ConfigItemDto } from '../config/config-item-dto.model';
export interface ConfigItemDtoPageList {
  count: number;
  data?: ConfigItemDto[];
  pageIndex: number;

}
