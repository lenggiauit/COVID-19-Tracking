(this["webpackJsonpcovid-19-tracking-app"]=this["webpackJsonpcovid-19-tracking-app"]||[]).push([[4],{16:function(e){e.exports=JSON.parse('{"BaseUrl":"https://covidapi.nagistar.com/","ForceHideEnvironment":true,"CountryViaIPUrl":"http://ip-api.com/json"}')},22:function(e,t,r){"use strict";r.d(t,"a",(function(){return a})),r.d(t,"b",(function(){return c}));var n=r(7),u=r(4),o=r(16),a=Object(n.a)({reducerPath:"GetTotalsCase",baseQuery:Object(u.d)({baseUrl:o.BaseUrl}),endpoints:function(e){return{getTotalsCase:e.query({query:function(){return{url:"GetTotalsCase",method:"get"}},transformResponse:function(e){return e}})}}}),c=a.useGetTotalsCaseQuery},23:function(e,t,r){"use strict";r.d(t,"a",(function(){return a})),r.d(t,"b",(function(){return c}));var n=r(7),u=r(4),o=r(16),a=Object(n.a)({reducerPath:"allCaseByRegion",baseQuery:Object(u.d)({baseUrl:o.BaseUrl}),endpoints:function(e){return{GetListCaseByRegion:e.query({query:function(){return{url:"GetAllCaseByRegion",method:"get"}},transformResponse:function(e){return e}})}}}),c=a.useGetListCaseByRegionQuery},24:function(e,t,r){"use strict";r.d(t,"a",(function(){return a})),r.d(t,"b",(function(){return c}));var n=r(7),u=r(4),o=r(16),a=Object(n.a)({reducerPath:"GetDetailByRegion",baseQuery:Object(u.d)({baseUrl:o.BaseUrl}),endpoints:function(e){return{GetDetailByRegion:e.query({query:function(e){return{url:"GetDetailByRegion",method:"post",body:e}},transformResponse:function(e){return e}})}}}),c=a.useGetDetailByRegionQuery},25:function(e,t,r){"use strict";r.d(t,"a",(function(){return a})),r.d(t,"b",(function(){return c}));var n=r(7),u=r(4),o=r(16),a=Object(n.a)({reducerPath:"GetTopByCountry",baseQuery:Object(u.d)({baseUrl:o.BaseUrl}),endpoints:function(e){return{getTopByCountry:e.query({query:function(){return{url:"GetTopByCountry",method:"get"}},transformResponse:function(e){return e}}),getTopCasesByCountry:e.query({query:function(){return{url:"GetTopCasesByCountry",method:"get"}},transformResponse:function(e){return e}}),GetTopDeathsByCountry:e.query({query:function(){return{url:"GetTopDeathsByCountry",method:"get"}},transformResponse:function(e){return e}})}}}),c=a.useGetTopByCountryQuery;a.useGetTopCasesByCountryQuery,a.useGetTopDeathsByCountryQuery},26:function(e,t,r){"use strict";r.d(t,"a",(function(){return a})),r.d(t,"b",(function(){return c}));var n=r(7),u=r(4),o=r(16),a=Object(n.a)({reducerPath:"GetCurrentCountry",baseQuery:Object(u.d)({baseUrl:o.CountryViaIPUrl}),endpoints:function(e){return{GetCurrentCountry:e.query({query:function(e){return{url:"",method:"get",body:e}},transformResponse:function(e){return e}})}}}),c=a.useGetCurrentCountryQuery},27:function(e,t,r){"use strict";r.d(t,"a",(function(){return a})),r.d(t,"b",(function(){return c}));var n=r(7),u=r(4),o=r(16),a=Object(n.a)({reducerPath:"GetTotalCaseByCountry",baseQuery:Object(u.d)({baseUrl:o.BaseUrl}),endpoints:function(e){return{GetTotalCaseByCountry:e.query({query:function(e){return{url:"GetTotalCaseByCountry",method:"post",body:e}},transformResponse:function(e){return e}})}}}),c=a.useGetTotalCaseByCountryQuery},28:function(e,t,r){"use strict";r.d(t,"a",(function(){return a})),r.d(t,"b",(function(){return c}));var n=r(7),u=r(4),o=r(16),a=Object(n.a)({reducerPath:"GetCountriesByRegion",baseQuery:Object(u.d)({baseUrl:o.BaseUrl}),endpoints:function(e){return{GetCountriesByRegion:e.query({query:function(e){return{url:"GetCountriesByRegion",method:"post",body:e}},transformResponse:function(e){return e}})}}}),c=a.useGetCountriesByRegionQuery},29:function(e,t,r){"use strict";r.d(t,"a",(function(){return a})),r.d(t,"b",(function(){return c}));var n=r(7),u=r(4),o=r(16),a=Object(n.a)({reducerPath:"GetDetailByCountry",baseQuery:Object(u.d)({baseUrl:o.BaseUrl}),endpoints:function(e){return{GetDetailByCountry:e.query({query:function(e){return{url:"GetDetailByCountry",method:"post",body:e}},transformResponse:function(e){return e}})}}}),c=a.useGetDetailByCountryQuery},46:function(e,t,r){},71:function(e,t,r){},74:function(e,t,r){"use strict";r.r(t);var n,u=r(0),o=r.n(u),a=r(19),c=r.n(a),s=function(e){e&&e instanceof Function&&r.e(10).then(r.bind(null,369)).then((function(t){var r=t.getCLS,n=t.getFID,u=t.getFCP,o=t.getLCP,a=t.getTTFB;r(e),n(e),u(e),o(e),a(e)}))},i=r(18),d=r(76),l=(r(46),r(21)),y=r.n(l),b=r(3),f=function(){return Object(b.jsx)("div",{className:"page-loading-logo",children:Object(b.jsx)("div",{className:"logo",children:Object(b.jsx)(y.a,{type:"Oval",color:"#74b4ff",height:"50",width:"50"})})})},j=r(38),h=(r(71),function(){var e=Object(j.usePromiseTracker)().promiseInProgress;return Object(b.jsx)(b.Fragment,{children:e&&Object(b.jsx)("div",{className:"spinner",children:Object(b.jsx)(y.a,{type:"Oval",color:"#74b4ff",height:"50",width:"50"})})})}),p=r(15),m=Object(p.a)(),O=Object(u.lazy)((function(){return Promise.all([Promise.all([r.e(0),r.e(3),r.e(1),r.e(7)]).then(r.bind(null,373)),new Promise((function(e){return setTimeout(e,20)}))]).then((function(e){return Object(i.a)(e,1)[0]}))})),C=Object(u.lazy)((function(){return Promise.all([Promise.all([r.e(0),r.e(2),r.e(1),r.e(9)]).then(r.bind(null,378)),new Promise((function(e){return setTimeout(e,20)}))]).then((function(e){return Object(i.a)(e,1)[0]}))})),g=Object(u.lazy)((function(){return Promise.all([Promise.all([r.e(0),r.e(2),r.e(3),r.e(1),r.e(8)]).then(r.bind(null,376)),new Promise((function(e){return setTimeout(e,20)}))]).then((function(e){return Object(i.a)(e,1)[0]}))})),B=function(){return Object(b.jsxs)(b.Fragment,{children:[Object(b.jsx)(d.b,{history:m,children:Object(b.jsx)(u.Suspense,{fallback:Object(b.jsx)(f,{}),children:Object(b.jsxs)(d.c,{children:[Object(b.jsx)(d.a,{path:"/",exact:!0,component:O}),Object(b.jsx)(d.a,{path:"/region",exact:!0,component:g}),Object(b.jsx)(d.a,{path:"/country",exact:!0,component:C})]})})}),Object(b.jsx)(h,{})]})},G=r(8),P=r(11),T=r(1),v=r(4),x=r(22),R=r(23),q=r(24),Q=r(25),U=r(26),w=r(27),D=Object(T.d)({name:"SelectedCountry",initialState:{},reducers:{selectCountry:function(e){e.value=e.value}}}),k=(D.actions.selectCountry,D.reducer),F=r(28),S=r(29),I=Object(T.a)({reducer:(n={},Object(P.a)(n,x.a.reducerPath,x.a.reducer),Object(P.a)(n,R.a.reducerPath,R.a.reducer),Object(P.a)(n,q.a.reducerPath,q.a.reducer),Object(P.a)(n,Q.a.reducerPath,Q.a.reducer),Object(P.a)(n,U.a.reducerPath,U.a.reducer),Object(P.a)(n,w.a.reducerPath,w.a.reducer),Object(P.a)(n,F.a.reducerPath,F.a.reducer),Object(P.a)(n,S.a.reducerPath,S.a.reducer),Object(P.a)(n,"selectedCountry",k),n),middleware:function(e){return e({serializableCheck:!1}).concat(x.a.middleware).concat(R.a.middleware).concat(q.a.middleware).concat(Q.a.middleware).concat(U.a.middleware).concat(w.a.middleware).concat(F.a.middleware).concat(S.a.middleware)}});Object(v.e)(I.dispatch),c.a.render(Object(b.jsx)(G.a,{store:I,children:Object(b.jsx)(o.a.StrictMode,{children:Object(b.jsx)(B,{})})}),document.getElementById("root")),s()}},[[74,5,6]]]);
//# sourceMappingURL=main.d274afdb.chunk.js.map