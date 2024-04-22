import { ConfigValueType } from '../enum/config-value-type.model';
/**
 * 配置添加时请求结构
 */
export interface ConfigAddDto {
  group: string;
  key: string;
  value: string;
  valueType?: ConfigValueType | null;

}
