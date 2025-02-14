import { Injectable } from '@angular/core';
import { SystemUserBaseService } from './system-user-base.service';

/**
 * 用户账户
 */
@Injectable({providedIn: 'root' })
export class SystemUserService extends SystemUserBaseService {
  id: string | null = null;
  name: string | null = null;
}