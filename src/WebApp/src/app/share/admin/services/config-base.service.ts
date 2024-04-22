import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ConfigFilterDto } from '../models/config/config-filter-dto.model';
import { ConfigAddDto } from '../models/config/config-add-dto.model';
import { ConfigUpdateDto } from '../models/config/config-update-dto.model';
import { ConfigItemDtoPageList } from '../models/config/config-item-dto-page-list.model';
import { Config } from '../models/config/config.model';
import { EnumDictionary } from '../models/config/enum-dictionary.model';

/**
 * 配置
 */
@Injectable({ providedIn: 'root' })
export class ConfigBaseService extends BaseService {
  /**
   * 筛选
   * @param data ConfigFilterDto
   */
  filter(data: ConfigFilterDto): Observable<ConfigItemDtoPageList> {
    const _url = `/api/admin/Config/filter`;
    return this.request<ConfigItemDtoPageList>('post', _url, data);
  }

  /**
   * 新增
   * @param data ConfigAddDto
   */
  add(data: ConfigAddDto): Observable<Config> {
    const _url = `/api/admin/Config`;
    return this.request<Config>('post', _url, data);
  }

  /**
   * 部分更新
   * @param id 
   * @param data ConfigUpdateDto
   */
  update(id: string, data: ConfigUpdateDto): Observable<Config> {
    const _url = `/api/admin/Config/${id}`;
    return this.request<Config>('patch', _url, data);
  }

  /**
   * 详情
   * @param id 
   */
  getDetail(id: string): Observable<Config> {
    const _url = `/api/admin/Config/${id}`;
    return this.request<Config>('get', _url);
  }

  /**
   * ⚠删除
   * @param id 
   */
  delete(id: string): Observable<Config> {
    const _url = `/api/admin/Config/${id}`;
    return this.request<Config>('delete', _url);
  }

  /**
   * 获取enums信息
   */
  getEnums(): Observable<Map<string, EnumDictionary[]>> {
    const _url = `/api/admin/Config/enums`;
    return this.request<Map<string, EnumDictionary[]>>('get', _url);
  }

}
