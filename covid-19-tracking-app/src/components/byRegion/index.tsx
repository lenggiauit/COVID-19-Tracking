import React, { useEffect, useState, useCallback } from 'react';
import { trackPromise } from 'react-promise-tracker';
import { toast, ToastContainer } from 'react-toastify';
import { useAppContext } from '../../contexts/appContext';
import { ApiResponse } from '../../type';
import * as bt from 'react-bootstrap';
import Placeholder from 'react-bootstrap/Placeholder';
import { Translation } from '../translation';
import { useGetListCaseByRegionQuery } from '../../services/getListCaseByRegion';
import LocalSpinner from "../localSpinner";
import { GetRandomBgColor } from '../../utils/functions';
import RegionItem from './item';
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import RegionDetail from './detail';

const ByRegion: React.FC = () => {

    const { data, error, isFetching, isLoading } = useGetListCaseByRegionQuery();

    const [selectedItem, setSelectedItem] = useState<Covid19DataByRegion>();

    const selectedItemHandler = useCallback((item: Covid19DataByRegion) => {
        setSelectedItem(item);
    }, [selectedItem])


    return (
        <>
            <ToastContainer />
            <bt.Container>
                <bt.Row>
                    <bt.Col md={4}>
                        <h5>
                            <Translation tid="Situation_by_WHO_Region" />
                        </h5>
                    </bt.Col>
                    <bt.Col md={8}>
                    </bt.Col>

                </bt.Row>
                <bt.Row>
                    <bt.Col md={4}>
                        {(isFetching || isLoading) &&
                            <>{
                                Array.from(Array(7).keys()).map((i) => (
                                    <RegionItem max={1} selectedItem={() => { }} />
                                ))
                            }
                            </>
                        }
                        {error && <div>{JSON.stringify(error)}</div>}
                        {!error && !isFetching &&
                            <> {
                                data?.resource.map((item) => (
                                    <>
                                        <RegionItem selectedItem={selectedItemHandler} data={item} max={Math.max.apply(Math, data?.resource.map(function (o) { return o.confirmed; }))} />
                                    </>
                                ))
                            }
                            </>
                        }
                    </bt.Col>
                    <bt.Col md={8}>
                        {!selectedItem && data?.resource[0] && (<>
                            <RegionDetail selectedItemData={data?.resource[0]} />
                        </>)}
                        {selectedItem && (<>
                            <RegionDetail selectedItemData={selectedItem} />
                        </>)}
                    </bt.Col>
                </bt.Row>

            </bt.Container>
        </>
    )
}

export default ByRegion;