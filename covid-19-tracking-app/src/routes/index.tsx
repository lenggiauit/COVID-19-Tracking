import React, { ReactElement, Suspense, lazy } from "react";
import { Router, Route, Switch } from "react-router-dom";
import PageLoading from "../components/pageLoading";
import GlobalSpinner from "../components/globalSpinner";
import history from "../utils/history";

const Home = lazy(() => {
    return Promise.all([
        import("../views/home/"),
        new Promise(resolve => setTimeout(resolve, 20))
    ])
        .then(([moduleExports]) => moduleExports);
});
const Country = lazy(() => {
    return Promise.all([
        import("../views/country"),
        new Promise(resolve => setTimeout(resolve, 20))
    ])
        .then(([moduleExports]) => moduleExports);
});

const Region = lazy(() => {
    return Promise.all([
        import("../views/region"),
        new Promise(resolve => setTimeout(resolve, 20))
    ])
        .then(([moduleExports]) => moduleExports);
});



const IndexRouter: React.FC = (): ReactElement => {
    return (
        <>
            <Router history={history}>
                <Suspense fallback={<PageLoading />}>
                    <Switch>
                        <Route path="/" exact component={Home} />
                        <Route path="/region" exact component={Region} />
                        <Route path="/country" exact component={Country} />
                    </Switch>
                </Suspense>
            </Router>
            <GlobalSpinner />
        </>
    );
};

export default IndexRouter;