// 该文件自动生成，会被覆盖更新
import { Injectable, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'enumText'
})
@Injectable({ providedIn: 'root' })
export class EnumTextPipe implements PipeTransform {
  transform(value: unknown, type: string): string {
    let result = '';
    switch (type) {
            case 'ApplicationType':
        {
            switch (value)
        {
            case 0: result = 'Web'; break;
            case 1: result = 'App'; break;
            case 2: result = '桌面'; break;
            case 3: result = '浏览器'; break;
            default: '默认'; break;
          }
        }
        break;
      case 'AuthorizationType':
        {
            switch (value)
        {
            case 0: result = '临时'; break;
            case 1: result = '永久'; break;
            default: '默认'; break;
          }
        }
        break;
      case 'ClientType':
        {
            switch (value)
        {
            case 0: result = '机密'; break;
            case 1: result = '公开'; break;
            default: '默认'; break;
          }
        }
        break;
      case 'ConfigValueType':
        {
            switch (value)
        {
            case 0: result = '数字'; break;
            case 1: result = '字符串'; break;
            case 2: result = '布尔值'; break;
            case 3: result = '对象'; break;
            case 4: result = '数组'; break;
            default: '默认'; break;
          }
        }
        break;
      case 'ConsentType':
        {
            switch (value)
        {
            case 0: result = '明确同意'; break;
            case 1: result = '系统默认'; break;
            case 2: result = '隐式同意'; break;
            default: '默认'; break;
          }
        }
        break;
      case 'Status':
        {
            switch (value)
        {
            case 0: result = '未激活'; break;
            case 1: result = '已兑换'; break;
            case 2: result = '已拒绝'; break;
            case 3: result = '已撤销'; break;
            case 4: result = '有效'; break;
            default: '默认'; break;
          }
        }
        break;
      case 'SubjectType':
        {
            switch (value)
        {
            case 0: result = '成对'; break;
            case 1: result = '公开'; break;
            default: '默认'; break;
          }
        }
        break;
      case 'TokenType':
        {
            switch (value)
        {
            case 0: result = 'Bearer'; break;
            default: '默认'; break;
          }
        }
        break;

      default:
        break;
    }
    return result;
  }
}