import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { Observable } from 'rxjs';
import { ScopeFilterDto } from './models/scope-filter-dto.model';
import { ScopeAddDto } from './models/scope-add-dto.model';
import { ScopeUpdateDto } from './models/scope-update-dto.model';
import { ScopeItemDtoPageList } from './models/scope-item-dto-page-list.model';
import { Scope } from './models/scope.model';

/**
 * Scope
 */
@Injectable({ providedIn: 'root' })
export class ScopeBaseService extends BaseService {
  /**
   * 筛选
   * @param data ScopeFilterDto
   */
  filter(data: ScopeFilterDto): Observable<ScopeItemDtoPageList> {
    const _url = `/api/admin/Scope/filter`;
    return this.request<ScopeItemDtoPageList>('post', _url, data);
  }

  /**
   * 新增
   * @param data ScopeAddDto
   */
  add(data: ScopeAddDto): Observable<string> {
    const _url = `/api/admin/Scope`;
    return this.request<string>('post', _url, data);
  }

  /**
   * 部分更新
   * @param id 
   * @param data ScopeUpdateDto
   */
  update(id: string, data: ScopeUpdateDto): Observable<boolean> {
    const _url = `/api/admin/Scope/${id}`;
    return this.request<boolean>('patch', _url, data);
  }

  /**
   * 详情
   * @param id 
   */
  getDetail(id: string): Observable<Scope> {
    const _url = `/api/admin/Scope/${id}`;
    return this.request<Scope>('get', _url);
  }

  /**
   * ⚠删除
   * @param id 
   */
  delete(id: string): Observable<boolean> {
    const _url = `/api/admin/Scope/${id}`;
    return this.request<boolean>('delete', _url);
  }

}
