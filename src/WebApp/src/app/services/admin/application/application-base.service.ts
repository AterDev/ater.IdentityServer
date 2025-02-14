import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { Observable } from 'rxjs';
import { ApplicationFilterDto } from './models/application-filter-dto.model';
import { ApplicationAddDto } from './models/application-add-dto.model';
import { ApplicationUpdateDto } from './models/application-update-dto.model';
import { ApplicationItemDtoPageList } from './models/application-item-dto-page-list.model';
import { Application } from './models/application.model';

/**
 * Application
 */
@Injectable({ providedIn: 'root' })
export class ApplicationBaseService extends BaseService {
  /**
   * 筛选
   * @param data ApplicationFilterDto
   */
  filter(data: ApplicationFilterDto): Observable<ApplicationItemDtoPageList> {
    const _url = `/api/admin/Application/filter`;
    return this.request<ApplicationItemDtoPageList>('post', _url, data);
  }

  /**
   * 新增
   * @param data ApplicationAddDto
   */
  add(data: ApplicationAddDto): Observable<string> {
    const _url = `/api/admin/Application`;
    return this.request<string>('post', _url, data);
  }

  /**
   * 部分更新
   * @param id 
   * @param data ApplicationUpdateDto
   */
  update(id: string, data: ApplicationUpdateDto): Observable<boolean> {
    const _url = `/api/admin/Application/${id}`;
    return this.request<boolean>('patch', _url, data);
  }

  /**
   * 详情
   * @param id 
   */
  getDetail(id: string): Observable<Application> {
    const _url = `/api/admin/Application/${id}`;
    return this.request<Application>('get', _url);
  }

  /**
   * ⚠删除
   * @param id 
   */
  delete(id: string): Observable<boolean> {
    const _url = `/api/admin/Application/${id}`;
    return this.request<boolean>('delete', _url);
  }

}
