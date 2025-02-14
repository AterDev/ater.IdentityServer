import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { Observable } from 'rxjs';
import { ConfigFilterDto } from './models/config-filter-dto.model';
import { ConfigAddDto } from './models/config-add-dto.model';
import { ConfigUpdateDto } from './models/config-update-dto.model';
import { ConfigItemDtoPageList } from './models/config-item-dto-page-list.model';
import { Config } from './models/config.model';
import { EnumDictionary } from './models/enum-dictionary.model';

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
  add(data: ConfigAddDto): Observable<string> {
    const _url = `/api/admin/Config`;
    return this.request<string>('post', _url, data);
  }

  /**
   * 部分更新
   * @param id 
   * @param data ConfigUpdateDto
   */
  update(id: string, data: ConfigUpdateDto): Observable<boolean> {
    const _url = `/api/admin/Config/${id}`;
    return this.request<boolean>('patch', _url, data);
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
  delete(id: string): Observable<boolean> {
    const _url = `/api/admin/Config/${id}`;
    return this.request<boolean>('delete', _url);
  }

  /**
   * 获取enums信息
   */
  getEnums(): Observable<Map<string, EnumDictionary[]>> {
    const _url = `/api/admin/Config/enums`;
    return this.request<Map<string, EnumDictionary[]>>('get', _url);
  }

}
