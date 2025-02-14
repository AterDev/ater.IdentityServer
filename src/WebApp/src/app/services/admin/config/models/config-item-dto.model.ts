import { ConfigValueType } from '../../enum/models/config-value-type.model';
/**
 * 配置列表元素
 */
export interface ConfigItemDto {
  group: string;
  key: string;
  value: any;
  valueType?: ConfigValueType | null;
  id: string;
  createdTime: Date;

}
