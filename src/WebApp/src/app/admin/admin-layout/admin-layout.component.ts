import { Component, ViewChild } from '@angular/core';
import { MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle } from '@angular/material/expansion';
import { MatSidenavModule } from '@angular/material/sidenav';
import { NgIf } from '@angular/common';
import { MatIconButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatNavList, MatListItem } from '@angular/material/list';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatTooltip } from '@angular/material/tooltip';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.scss',
  imports: [MatSidenavModule, NgIf, MatIconButton, MatIcon, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatNavList, MatListItem, RouterLink, RouterLinkActive, RouterOutlet, MatTooltip]
})
export class AdminLayoutComponent {
  events: string[] = [];
  opened = true;
  expanded = true;
  @ViewChild(MatAccordion, { static: true }) accordion!: MatAccordion;
  constructor() {

  }

  ngOnInit(): void {
    if (this.expanded) {
      this.accordion?.openAll();
    } else {
      this.accordion?.closeAll();
    }
  }

  toggle(): void {
    this.opened = !this.opened;
  }
}
