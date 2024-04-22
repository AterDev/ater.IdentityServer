import { ConfigValueType } from '../enum/config-value-type.model';
/**
 * 配置
 */
export interface Config {
  group: string;
  key: string;
  value: any;
  valueType?: ConfigValueType | null;
  id: string;
  createdTime: Date;
  updatedTime: Date;
  isDeleted: boolean;

}
