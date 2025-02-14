import { ConfigItemDto } from '../../config/models/config-item-dto.model';
export interface ConfigItemDtoPageList {
  count: number;
  data?: ConfigItemDto[];
  pageIndex: number;

}
