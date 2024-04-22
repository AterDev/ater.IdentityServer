import { Injectable } from '@angular/core';
import { ConfigBaseService } from './config-base.service';

/**
 * 配置
 */
@Injectable({providedIn: 'root' })
export class ConfigService extends ConfigBaseService {
  id: string | null = null;
  name: string | null = null;
}