import { ConfigValueType } from '../../enum/models/config-value-type.model';
/**
 * 配置更新时请求结构
 */
export interface ConfigUpdateDto {
  group?: string | null;
  key?: string | null;
  value?: string | null;
  valueType?: ConfigValueType | null;

}
