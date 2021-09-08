import React, { useState, useCallback } from 'react';
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
import { useGetListCaseByRegionQuery } from '../../services/getListCaseByRegion';
import LocalSpinner from "../localSpinner";
import { GetRandomBgColor } from '../../utils/functions';
import RegionItem from './item';
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import { uuid } from 'uuidv4';
import { useHistory } from "react-router-dom";


const ByRegion: React.FC = () => {

    const { data, error, isFetching, isLoading } = useGetListCaseByRegionQuery();

    const [selectedRegion, setSelectedRegion] = useState<Covid19DataByRegion>();
    const history = useHistory();

    const selectedRegionHandler = (item: Covid19DataByRegion) => {
        history.push('/region', item);
    };

    return (
        <>
            <bt.Row>
                <bt.Col >

                    {(isFetching || isLoading) && (
                        <bt.Placeholder as="a" animation="glow">
                            <bt.Placeholder xs={5} bg={GetRandomBgColor()} size="lg" />
                        </bt.Placeholder>)}
                    {!error && !isFetching && <h5> <Translation tid="Situation_by_WHO_Region" /> </h5>}

                </bt.Col>
            </bt.Row>
            <bt.Row>
                <bt.Col >
                    {(isFetching || isLoading) &&
                        <>{
                            Array.from(Array(7).keys()).map((i) => (
                                <RegionItem key={uuid()} max={1} selectedItem={() => { }} />
                            ))
                        }
                        </>
                    }
                    {error && <div>{JSON.stringify(error)}</div>}
                    {!error && !isFetching && data?.success && data?.resource != null &&
                        <> {
                            data?.resource.map((item) => (
                                <>
                                    <RegionItem key={uuid()} selectedItem={selectedRegionHandler} data={item} max={Math.max.apply(Math, data?.resource.map(function (o) { return o.confirmed; }))} />
                                </>
                            ))
                        }
                        </>
                    }
                </bt.Col>
            </bt.Row>

        </>
    )
}

export default ByRegion;