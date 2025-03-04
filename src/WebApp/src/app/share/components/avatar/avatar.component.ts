import { SlicePipe } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-avatar',
  imports: [SlicePipe],
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.css'],
})
export class AvatarComponent {
  @Input()
  avatar: string | null | undefined = null;
  @Input()
  name: string | null | undefined = null;
  @Input()
  size: number = 20;
  constructor() {

  }

}
