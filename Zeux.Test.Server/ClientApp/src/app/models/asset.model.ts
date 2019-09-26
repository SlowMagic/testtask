export class AssetViewModel {
    constructor(
      public name: string,
      public percent: number,
      public sum: number,
      public typeName: string) { }
  }

  export class AssetType {
    constructor(
      public id: number,
      public name: string) { }
  }