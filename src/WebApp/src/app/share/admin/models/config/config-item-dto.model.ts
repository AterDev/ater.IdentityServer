import { ConfigValueType } from '../enum/config-value-type.model';
/**
 * 配置列表元素
 */
export interface ConfigItemDto {
  group: string;
  key: string;
  value: string;
  valueType?: ConfigValueType | null;
  id: string;
  createdTime: Date;

}
