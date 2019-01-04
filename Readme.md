## 生成sql

sql builder,Sql generator. 
sql生成类库开发，支持(net45,net46,net47,dotnet),支持数据库（sqlsrver,mysql,postgresql)

## 使用
```

var builder = new SqlServerBuilder();
builder.Select<Sample>(t => new object[] { t.Email, t.BoolValue })
    .Select<Sample2>(t => new object[] { t.Description, t.IntValue })
    .From<Sample>("a")
    .LeftJoin<Sample2>("b").On<Sample, Sample2>((l, r) => l.Email == r.StringValue && l.IntValue != r.IntValue);

string sqlStr=_builder.ToSql();

```

## 项目源自于Util

https://github.com/dotnetcore/Util

Util是一个.net core平台下的应用框架，旨在提升小型团队的开发输出能力，由常用公共操作类(工具类)、分层架构基类、Ui组件，第三方组件封装，第三方业务接口封装，配套代码生成模板，权限等组成。
