import { Injectable } from '@angular/core';
import { ScopeBaseService } from './scope-base.service';

/**
 * Scope
 */
@Injectable({providedIn: 'root' })
export class ScopeService extends ScopeBaseService {
  id: string | null = null;
  name: string | null = null;
}