import { ApplicationItemDto } from '../application/application-item-dto.model';
export interface ApplicationItemDtoPageList {
  count: number;
  data?: ApplicationItemDto[];
  pageIndex: number;

}
