import { ApplicationItemDto } from '../../application/models/application-item-dto.model';
export interface ApplicationItemDtoPageList {
  count: number;
  data?: ApplicationItemDto[];
  pageIndex: number;

}
