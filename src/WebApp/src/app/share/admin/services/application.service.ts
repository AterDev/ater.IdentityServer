import { Injectable } from '@angular/core';
import { ApplicationBaseService } from './application-base.service';

/**
 * Application
 */
@Injectable({providedIn: 'root' })
export class ApplicationService extends ApplicationBaseService {
  id: string | null = null;
  name: string | null = null;
}