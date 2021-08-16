import React, { ReactElement, Suspense, lazy } from "react";
import { Router, Route, Switch } from "react-router-dom";
import PageLoading from "../components/pageLoading";
import history from "../utils/history";

const Home = lazy(() => {
    return Promise.all([
        import("../views/home/"),
        new Promise(resolve => setTimeout(resolve, 500))
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
                    </Switch>
                </Suspense>
            </Router>
        </>
    );
};

export default IndexRouter;